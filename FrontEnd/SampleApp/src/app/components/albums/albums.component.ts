import { Component, OnInit, Input } from '@angular/core';
import {Album} from "../../../Types/album";
import {DataService} from "../../../services/data.service";
import {User} from "../../../Types/user";
import {Photo} from "../../../Types/photo";
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-albums',
  templateUrl: './albums.component.html',
  styleUrls: ['./albums.component.css']
})
export class AlbumsComponent implements OnInit {
  public albums: Album[];
  selectedAlbum: Album;
  public albphotos: Photo[];
  public userId: number;

  constructor(private data: DataService, private route: ActivatedRoute) {
  }

  ngOnInit() {
      this.route.queryParams.subscribe(params=> this.userId = params.userId)
      this.data.getAlbums(this.userId).subscribe(r => this.albums = r);
  }


  onSelect(album: Album) {
    this.selectedAlbum= album;
  }


}




