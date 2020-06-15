import {Component, Input, OnInit} from '@angular/core';
import {DataService} from "../../../services/data.service";
import {Album} from "../../../Types/album";
import {Photo} from "../../../Types/photo";
import {User} from "../../../Types/user";

@Component({
  selector: 'app-photos',
  templateUrl: './photos.component.html',
  styleUrls: ['./photos.component.css']
})
export class PhotosComponent implements OnInit {
  @Input() album: Album
  @Input() onlyFirst: boolean
  public photos: Photo[];
  public firstphoto: Photo;



  constructor(private data: DataService) {
  }


  ngOnInit() {
    this.data.getPhotos(this.album.id).subscribe(r => this.photos = r);
  }


}
