import {Photo} from "./photo";

export interface Album {
  albphotos: Photo[];
  userId: number,
  id: number,
  title: string
}
