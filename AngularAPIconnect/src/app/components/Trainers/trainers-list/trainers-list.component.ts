import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { Trainers } from 'src/app/models/trainers.model';
import { EmpService } from 'src/app/services/emp.service';

@Component({
  selector: 'app-trainers-list',
  templateUrl: './trainers-list.component.html',
  styleUrls: ['./trainers-list.component.css']
})
export class TrainersListComponent implements OnInit {
  
  trainers:Trainers[]=[];
  constructor(private empservices:EmpService,private router:Router){}
  ngOnInit(): void {
    this.empservices.getAllTrainers()
    .subscribe({
      next:(trainers)=>{
        this.trainers=trainers;
      },
      error:(response)=>{
        console.log(response);
      }
    })
  }
  deleteTrainer(value:string) {
    console.log(value);
    this.empservices.delTrainer(value)
    .subscribe({
      next:response=>{
        window.alert("Account Deleted");
        window.location.reload();
      }
    })
  }
}
