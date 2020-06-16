import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {AlbumsComponent} from "../components/albums/albums.component";
import {AppComponent} from "../app.component";
import {UsersComponent} from "../components/users/users.component";
import {PhotosComponent} from "../components/photos/photos.component";

const routes: Routes = [
  {
    path: '',
    component: UsersComponent
  },
  {
    path: 'albums-page',
    component: AlbumsComponent
  },
  {
    path: 'photos-page',
    component: PhotosComponent
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ],
  declarations: []
})
export class AppRoutingModule { }
