import {Component, Input, OnInit} from '@angular/core';
import {Album} from '../../../Types/album';
import {DataService} from '../../../services/data.service';
import {Photo} from '../../../Types/photo';
import {User} from '../../../Types/user';

@Component({
  selector: 'app-photos',
  templateUrl: './photos.component.html',
  styleUrls: ['./photos.component.css']
})
export class PhotosComponent implements OnInit {
  @Input() album: Album;
  public photos: Photo[];
  public selectedPhoto: Photo;

  constructor(private data: DataService) { }

  ngOnInit() {
    this.data.getPhotos(this.album.id).subscribe(r => this.photos = r);
  }

  onSelect(photo: Photo): void {
    this.selectedPhoto = photo;
  }
}
