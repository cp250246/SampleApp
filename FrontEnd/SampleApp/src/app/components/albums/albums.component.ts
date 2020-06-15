import { Component, OnInit, Input } from '@angular/core';
import {Album} from "../../../Types/album";
import {DataService} from "../../../services/data.service";
import {User} from "../../../Types/user";

@Component({
  selector: 'app-albums',
  templateUrl: './albums.component.html',
  styleUrls: ['./albums.component.css']
})
export class AlbumsComponent implements OnInit {
  @Input() user: User
  public albums: Album[];
  selectedAlbum: Album;

  constructor(private data: DataService) {
  }

  ngOnInit() {
      this.data.getAlbums(this.user.id).subscribe(r => this.albums = r);
  }


  onSelect(album: Album) {
    this.selectedAlbum= album;

  }


}




