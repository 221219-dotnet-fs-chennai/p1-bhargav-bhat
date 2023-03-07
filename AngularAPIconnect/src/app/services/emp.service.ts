import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { Trainers } from '../models/trainers.model';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class EmpService {

  baseApiUrl:string=environment.baseApiUrl;
  constructor(private http:HttpClient ) { }

  getAllTrainers():Observable<Trainers[]> {
      return this.http.get<Trainers[]>(this.baseApiUrl+'/api/TrainerControl/Fetch_Trainers');
  }

  addTrainers(addTrainerRequest:Trainers): Observable<Trainers> {
    return this.http.post<Trainers>(this.baseApiUrl+'/api/TrainerControl/Add_Trainer',addTrainerRequest);
  }

  getTrainer(email:string,password:string):Observable<Trainers>{
    let headers=new HttpHeaders({
      'Content-Type':'application/json',
      'responseType':'json',
      'email':email,
      'password':password
    })
    return this.http.get<Trainers>(this.baseApiUrl+'/api/TrainerControl/Verify/',{headers:headers})
  }

  updateTrainer(email:string,upTrainerRequest:Trainers):Observable<Trainers> {
    let headers=new HttpHeaders({
      'Content-Type':'application/json',
      'responseType':'json',
      'email':email,})
      return this.http.put<Trainers>(this.baseApiUrl+'/api/TrainerControl/Update',upTrainerRequest,{headers:headers})
  }

  delTrainer(email:string):Observable<Trainers>{
    let headers=new HttpHeaders({
      'Content-Type':'application/json',
      'responseType':'json',
      'email':email,})
    return this.http.delete<Trainers>(this.baseApiUrl+'/api/TrainerControl/Delete_Trainer',{headers:headers})
  }
}
