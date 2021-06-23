import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/core/services/user.service';
import { UserDetails } from 'src/app/models/userDetail';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {

  id!: number;
  userDetail: UserDetails | undefined;
  constructor(private userService: UserService, private route: ActivatedRoute) { }

  ngOnInit(): void {

    this.route.paramMap.subscribe(
      params => {
        this.id = Number(params.get("id"));
        this.userService.getUserDetailById(this.id).subscribe(
          u => this.userDetail = u);
          console.log(this.userDetail);
        
      }
    )
 }
}
