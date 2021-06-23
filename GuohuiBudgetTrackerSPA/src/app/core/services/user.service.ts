import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from 'src/app/models/user';
import { UserCreate } from 'src/app/models/userAdd';
import { UserDetails } from 'src/app/models/userDetail';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private apiService: ApiService){}

  getAllUsers() : Observable<User[]>{
    return this.apiService.getList("User");
  }

  getUserDetailById(id: number) : Observable<UserDetails>{
    return this.apiService.getOne(`${'User/detail/'}`,id)
 
  }
}
