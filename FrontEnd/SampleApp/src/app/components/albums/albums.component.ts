import {Component, Input, OnInit} from '@angular/core';
import { DataService } from 'src/services/data.service';
import { Album } from 'src/Types/album';
import {User} from '../../../Types/user';

@Component({
  selector: 'app-albums',
  templateUrl: './albums.component.html',
  styleUrls: ['./albums.component.css']
})
export class AlbumsComponent implements OnInit {
  @Input() user: User
  public albums: Album[];
  constructor(private data: DataService) { }

  ngOnInit() {
    this.data.getAlbums(this.user.id).subscribe(r => this.albums = r);

  }

}
