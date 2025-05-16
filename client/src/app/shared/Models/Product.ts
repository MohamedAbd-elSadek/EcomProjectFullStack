import { Photo } from "./Photo"

export interface Product {
  productId: string
  name: string
  description: string
  manufactureDate: string
  price: number
  discount: number
  categoryName: string
  photos: Photo[]
}

