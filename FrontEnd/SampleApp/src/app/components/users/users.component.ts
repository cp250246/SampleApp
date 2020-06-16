import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/services/data.service';
import { User } from 'src/Types/user';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  public users: User[]
  public selectedUser: User;


  constructor(private data: DataService) { }

  ngOnInit() {
    this.data.getUsers().subscribe(r => this.users = r);
  }

  onSelect(user: User): void {
    this.selectedUser = user;
  }

}
