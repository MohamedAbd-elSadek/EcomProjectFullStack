import { Component, OnInit } from '@angular/core';
import { ShopService } from './shop.service';
import { Product } from '../shared/Models/Product';
import { Photo } from '../shared/Models/Photo';
import { Category } from '../shared/Models/Category';
import { ProductParam } from '../shared/Models/ProductParam';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-shop',
  standalone: false,
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.css'
})
export class ShopComponent implements OnInit {
  constructor(private readonly shopService:ShopService,private toastr: ToastrService){

  }
  ngOnInit(): void {
   this.getAllProducts();
   this.getAllCategories();
  }
  //GetProducts
  product: Product[] = [];
  photo:Photo[]
  totalItems: number = 0;
  currentPage: number = 1;
  itemsOnCurrentPage:number


  Params=new ProductParam()

   getAllProducts(){
    this.shopService.getProduct(this.Params).subscribe({
      next: (value) => {
        this.product = value.data;
        this.totalItems = value.totalCount;
        this.itemsOnCurrentPage=value.data.length
        console.log(this.product);
        
      }
    })
    console.log(this.product.length);
    
    if(this.product.length != 0){
          this.toastr.success("All products Loaded")
    }else{
      this.toastr.error("Error Loading Products")
    }
  }

  //GetCategories
  category:Category[]
  // categoryId:string
  getAllCategories(){
    this.shopService.getCategory().subscribe({
      next:((value:Category[])=>{
        this.category=value;
      })
    })
  }

  selectedCategory(categoryID:string){
    this.Params.categoryId = categoryID
    
    this.getAllProducts();
  }

  //Sorting by Price

  SortingOptions =[
    {name:"Name",value:"Name"},
    {name:"Price:Min-Max",value:"priceasc"},
    {name:"Price:Max-Min",value:"pricedesc"}
  ]

  // sortingOption:string;

  OptionSelection(sort: Event) {
    this.Params.sortingOption=(sort.target as HTMLInputElement ).value
    
    this.getAllProducts();
}

//sorting by search

// search:string

onSearch(Search:string){
this.Params.search=Search;
this.getAllProducts();
}

//reset button

formSearch:string=""

resetValue(){
  this.Params.search=""
  this.Params.sortingOption="Name"
  this.Params.categoryId=""
  this.Params.pageNumber=1

   this.currentPage = 1;
  
  this.getAllProducts();
  this.formSearch=""

}

OnPageChange(page:any){
  this.currentPage = page;
  this.Params.pageNumber=page
  
  this.getAllProducts();
}


    
  }