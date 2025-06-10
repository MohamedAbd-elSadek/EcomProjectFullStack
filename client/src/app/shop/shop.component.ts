import { Component, OnInit } from '@angular/core';
import { ShopService } from './shop.service';
import { Product } from '../shared/Models/Product';
import { Category } from '../shared/Models/Category';
import { ProductParam } from '../shared/Models/ProductParam';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-shop',
  standalone: false,
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
  product: Product[] = [];
  category: Category[];
  totalItems: number = 0;
  currentPage: number = 1;
  itemsOnCurrentPage: number;

  Params = new ProductParam();

  SortingOptions = [
    { name: "Name", value: "Name" },
    { name: "Price: Min-Max", value: "priceasc" },
    { name: "Price: Max-Min", value: "pricedesc" }
  ];

  formSearch: string = "";

  constructor(
    private readonly shopService: ShopService,
    private readonly toastr: ToastrService,
    private readonly router: Router,
    private readonly route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.Params.pageNumber = params['pageNumber'] ? +params['pageNumber'] : 1;
      this.Params.categoryId = params['categoryId'] || '';
      this.Params.sortingOption = params['sort'] || 'Name';
      this.Params.search = params['search'] || '';
      
      this.currentPage = this.Params.pageNumber;
      this.formSearch = this.Params.search;
      
      this.getAllProducts();
    });

    this.getAllCategories();
  }

  getAllProducts() {
    this.shopService.getProduct(this.Params).subscribe({
      next: (value) => {
        if (value) {
          this.product = value.data;
          this.totalItems = value.totalCount;
          this.itemsOnCurrentPage = value.data.length; 
        }
      },
      error: (err) => {
        this.toastr.error("Failed to load products.", "ERROR");
        console.error(err);
      }
    });
  }

  getAllCategories() {
    this.shopService.getCategory().subscribe({
      next: (value: Category[]) => {
        this.category = value;
      }
    });
  }

  selectedCategory(categoryID: string) {
    this.updateQueryParams({ categoryId: categoryID || null, pageNumber: 1 });
  }

  OptionSelection(sortEvent: Event) {
    const sortValue = (sortEvent.target as HTMLSelectElement).value;
    this.updateQueryParams({ sort: sortValue, pageNumber: 1 });
  }

  onSearch(search: string) {
    this.formSearch = search;
    this.updateQueryParams({ search: this.formSearch.trim() || null, pageNumber: 1 });
  }

  resetValue() {
    this.formSearch = '';
    this.router.navigate(['/shop']);
  }

  OnPageChange(page: number) {
    if (this.Params.pageNumber !== page) {
      this.updateQueryParams({ pageNumber: page });
    }
  }


  private updateQueryParams(params: object) {
    this.router.navigate([], {
      relativeTo: this.route,
      queryParams: params,
      queryParamsHandling: 'merge', 
    });
  }
}