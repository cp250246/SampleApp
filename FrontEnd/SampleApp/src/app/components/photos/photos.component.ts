import {Component, Input, OnInit} from '@angular/core';
import {DataService} from "../../../services/data.service";
import {Album} from "../../../Types/album";
import {Photo} from "../../../Types/photo";
import {User} from "../../../Types/user";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-photos',
  templateUrl: './photos.component.html',
  styleUrls: ['./photos.component.css']
})
export class PhotosComponent implements OnInit {
  public photos: Photo[];
  public albumId: number;
  public showAll: boolean = false;


  constructor(private data: DataService, private route: ActivatedRoute) {
  }


  ngOnInit() {
    this.route.queryParams.subscribe(params=> {this.albumId = params.albumId})
    this.data.getPhotos(this.albumId).subscribe(r => this.photos = r);

  }

  showall() {
    this.showAll = !this.showAll;
  }


}
