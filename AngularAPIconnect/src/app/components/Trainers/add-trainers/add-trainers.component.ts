import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Trainers } from 'src/app/models/trainers.model';
import { EmpService } from 'src/app/services/emp.service';

@Component({
  selector: 'app-add-trainers',
  templateUrl: './add-trainers.component.html',
  styleUrls: ['./add-trainers.component.css']
})
export class AddTrainersComponent implements OnInit {
  [x: string]: any;

  addTrainerRequest:Trainers={
    id:0,
    firstName:'',
    lastName:'',
    gender:'',
    email:'',
    password:'',
    phone:'',
    city:'',
    state:'',
    country:'',
    aboutme:''

  }
  ngOnInit(): void {
    
  }
  constructor(private trainerservices:EmpService,private router:Router){}

  addTrainers(){
    console.log(this.addTrainerRequest);
    this.trainerservices.addTrainers(this.addTrainerRequest)
    .subscribe({
      next:(trainer)=>{
        window.alert("Trainer Added...!");
        this.router.navigate(['/trainer']);
        console.log(trainer);
      }
    })
    
  }

}
