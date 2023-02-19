function login() {
    document.getElementById("bt1").addEventListener("click",function(event){
        event.preventDefault();
    
        var email=document.getElementById("e1").value;
        var password=document.getElementById("p1").value;
        localStorage.setItem("Email",email);
        localStorage.setItem("Pass",password);
        fetch('https://localhost:7181/api/TrainerControl/Verify',{
            method:'GET',
            headers:{'Content-Type': 'application/json',    
        'email': email,
        'password': password}
    }).then(response=> {
        if(response.status===200){
            alert("Successfully Logged In");
            window.location.href='AfterLogin.html';
        }
        else{
            alert("Login Failed, Please try again");
        }
    })
    });
    }

function UserDetails() {
    let emailid=localStorage.getItem("Email");
    let password=localStorage.getItem("Pass");
    fetch('https://localhost:7181/api/TrainerControl/Verify',{
        method:'GET',
        headers:{'Content-Type': 'application/json',
    'email': emailid,
    'password': password}
}).then(response=> {
    if(response.status===200){
        return response.json();
    }
    else{
        alert("Error Occured");
    }
}).then(trainer=> {
    tdata=JSON.stringify(trainer);
    localStorage.setItem("user",trainer.firstName);
    const markup1=`${trainer.firstName} ${trainer.lastName}`;
    const markup=`<div class="card" id="dis"><div class="card-body row g-3">
                <div class="col-md-3">
                <b>Full Name : </b>${trainer.firstName} ${trainer.lastName}
                </div>
                <div class="col-md-3">
                <b>Gender : </b>${trainer.gender}
                </div>
                <div class="col-md-3">
                <b>Email : </b>${trainer.email}
                </div>
                <div class="col-md-3">
                <b>Phone Number : </b>${trainer.phone}
                </div>
                <div class="col-md-3">
                <b>City : </b>${trainer.city}
                </div>
                <div class="col-md-3">
                <b>State : </b>${trainer.state}
                </div>
                <div class="col-md-3">
                <b>Country : </b>${trainer.country}
                </div>
                <div class="col-md-12">
                <b>About Me : </b>${trainer.aboutme}
                </div>
                <div class="col-md-6">
                <button class="profile" value='${tdata}' style="border-radius:8px" onclick="fetchTrainer(value)" id="btp"">Update </button>
                </div>
                <div class="col-md-4">
                <button class="profile" id="btp1" value='${tdata}' style="border-radius:8px" onclick="deleteProfile(value)"">Delete Profile</button>
                </div>
                </div></div>`;
                document.querySelector('#divtra').insertAdjacentHTML('afterbegin',markup);
                console.log(markup1);
                document.querySelector('#proname').insertAdjacentHTML('afterbegin',markup1);
})

}

function signup() 
{
    const form=document.getElementById('formda');
    form.addEventListener('submit', event=> {
        event.preventDefault();});

        const formData = new FormData(form);

        const data=Object.fromEntries(formData);
        console.log(data);

        fetch('https://localhost:7181/api/TrainerControl/Add_Trainer', {
        method:'POST',
        headers: {
            'Content-Type': 'application/json'
          },
        body:JSON.stringify(data),
    }).then(response=> {
        if(response.ok) {
            console.log("Success");
            alert("Successfully Registered");
            window.location.replace('LoginPage.html');
        }
        else{
            response.text().then(function(text){
                alert(text);
            })
        }
    })
    .catch(error=>{
        alert("Some Error Occured,Please try after some time...")
    });
    
}

function getEducation() {

    let emailid=localStorage.getItem("Email");
    console.log("")
    fetch('https://localhost:7181/api/Education/Fetch_Education_Details',{
        method:'GET',
        headers:{
                'email': emailid
}
}).then(response=> {
    if(response.ok){
        return response.json();
    }
    else{
        return;
    }
}).then(education=>{education.forEach(edu => {
                
            edata=JSON.stringify(edu);
            const markup1=`<div class="card" id="dis"><div class="card-body row g-3">
                <div class="col-md-4" id="e11">
                <b>College or University : </b>${edu.college_Uni}
                </div>
                <div class="col-md-4" id="e12">
                <b>Degree : </b>${edu.degree}
                </div>
                <div class="col-md-2">
                <button class="open-button" value='${edata}' style="border-radius: 8px;margin-left: 3px;margin-right: 3px;" onclick="fetchFields(value)" id="btu"">Update</button>
                </div>
                <div class="col-md-2">
                <button class="dlt" id="btu" style="border-radius: 8px;margin-left: 3px;margin-right: 3px;margin-bottom:0" value='${edata}' onclick="deleteEducation(value)""><i class="fa fa-trash"></i></button>
                </div>
                <div class="col-md-2" id="e13">
                <b>Start Date : </b>${edu.start_Date}
                </div>
                <div class="col-md-2" id="e14">
                <b>End Date : </b>${edu.end_Date}
                </div>
                <div class="col-md-3" id="e15">
                <b>Description : </b>${edu.descriptions}
                </div>
               
                </div></div>`;
                document.querySelector('#edudiv').insertAdjacentHTML('afterbegin',markup1);
})

});
}

function getWorkDetails() {

    let emailid=localStorage.getItem("Email");
    console.log("")
    fetch('https://localhost:7181/api/Work/Fetch_Work_Experience_Details',{
        method:'GET',
        headers:{
                'email': emailid
}
}).then(response=> {
    if(response.ok){
        return response.json();
    }
    else{
        return;
    }
}).then(worke=>{worke.forEach(w => {
                
            wdata=JSON.stringify(w);
            const markup1=`<div class="card" id="dis"><div class="card-body row g-3">
                <div class="col-md-4">
                <b>Company Name : </b>${w.company_Name}
                </div>
                <div class="col-md-4">
                <b>Role : </b>${w.role}
                </div>
                <div class="col-md-2">
                <button class="open-button" value='${wdata}' style="border-radius: 8px;margin-left: 3px;margin-right: 3px;" onclick="fetchFieldsw(value)" id="btu"">Update</button>
                </div>
                <div class="col-md-2">
                <button class="dlt" style="border-radius: 8px;margin-left: 3px;margin-right: 3px;margin-bottom:0" value='${wdata}' onclick="deleteWork(value)""><i class="fa fa-trash"></i></button>
                </div>
                <div class="col-md-2">
                <b>Start Date : </b>${w.startDate}
                </div>
                <div class="col-md-2">
                <b>End Date : </b>${w.endDate}
                </div>
                <div class="col-md-3">
                <b>Description : </b>${w.description}
                </div>
                </div></div>`;
                document.querySelector('#workdiv').insertAdjacentHTML('afterbegin',markup1);
})

});
}

function getSkills() {

    let emailid=localStorage.getItem("Email");
    console.log("")
    fetch('https://localhost:7181/api/Skills/Fetch_Skills',{
        method:'GET',
        headers:{
                'email': emailid
}
}).then(response=> {
    if(response.ok){
        return response.json();
    }
    else{
        return;
    }
}).then(skill=>{skill.forEach(skill => {
                
            sdata=JSON.stringify(skill);
            localStorage.setItem("skl",skill.skillName);
            const markup1=`<div class="card" id="dis"><div class="card-body row g-3">
                <div class="col-md-8">
                <b>Skill Name : </b>${skill.skillName}
                </div>
                <div class="col-md-2">
                <button class="open-button" style="border-radius: 8px;margin-left: 3px;margin-right: 3px;">Update</button>
                </div>
                <div class="col-md-2">
                <button class="dlt" style="border-radius: 8px;margin-left: 3px;margin-right: 3px;margin-bottom:0" value='${sdata}' onclick="deleteSkill(value)""><i class="fa fa-trash"></i></button>
                </div>
                </div></div>`;
                document.querySelector('#skilldiv').insertAdjacentHTML('afterbegin',markup1);
})

});
}

function getAdditional() {

    let emailid=localStorage.getItem("Email");
    console.log("")
    fetch('https://localhost:7181/api/Additional/Fetch_Additional_Details',{
        method:'GET',
        headers:{
                'email': emailid
}
}).then(response=> {
    if(response.ok){
        return response.json();
    }
    else{
        return;
    }
}).then(add=>{add.forEach(a => {
            adata=JSON.stringify(a);
            const markup1=`<div class="card" id="dis"><div class="card-body row g-3">
                <div class="col-md-8">
                <b>Title : </b>${a.title}
                </div>
                <div class="col-md-2">
                <button class="open-button" value='${adata}' style="border-radius: 8px;margin-left: 3px;margin-right: 3px;margin-bottom:0" onclick="fetchFieldsAdd(value)" id="btu"">Update</button>
                </div>
                <div class="col-md-2">
                <button class="dlt" style="border-radius: 8px;margin-left: 3px;margin-right: 3px;margin-bottom:0" value='${adata}' onclick="deleteAdd(value)""><i class="fa fa-trash"></i></button>
                </div>
                <div class="col-md-12">
                <b>Achievements : </b>${a.achievments}
                </div>
                <div class="col-md-12">
                <b>Publications : </b>${a.publications}
                </div>
                <div class="col-md-12">
                <b>Volunteering Experiences : </b>${a.volunteering_Experiences}
                </div>
                
                </div></div>`;
                document.querySelector('#adddiv').insertAdjacentHTML('afterbegin',markup1);
})

});
}

function addEducation() {

    const form=document.getElementById('myF');
    form.addEventListener('submit', event=> {
        event.preventDefault();});

        const formData = new FormData(form);

        const data=Object.fromEntries(formData);
        console.log(data);
        let emailid=localStorage.getItem("Email");

        fetch('https://localhost:7181/api/Education/Add_Educations', {
        method:'POST',
        headers: {
            'Content-Type': 'application/json',
            'email':emailid
          },
        body:JSON.stringify(data),
    }).then(response=> {
        if(response.status===200) {
            alert("Education Added Succesfully")
            window.location.reload('AfterLogin.html');
        }
    })
    .catch(error=>{
        alert("Some Error Occured,Please try after some time...")
    });
}

function fetchFields(value) {
    
    eddata=JSON.parse(value);
    console.log(eddata);
    localStorage.setItem("college",eddata.college_Uni);
    const form = document.querySelector('#myFormUpdate');
    
    a=form.querySelector('#e1').value=eddata.college_Uni;
    console.log(a)
    form.querySelector('#e2').value=eddata.degree;
    form.querySelector('#e3').value=eddata.start_Date;
    form.querySelector('#e4').value=eddata.end_Date;
    form.querySelector('#e5').value=eddata.descriptions;

    openForm1();
    
}

function updateEducation()
{
    const form=document.getElementById('myFUpdate');
    form.addEventListener('submit', event=> {
        event.preventDefault();});

        const formData = new FormData(form);

        const data=Object.fromEntries(formData);
        console.log(data);
        let emailid=localStorage.getItem("Email");
        let clg=localStorage.getItem("college");
        console.log(clg);
        fetch('https://localhost:7181/api/Education/Update_Education', {
        method:'PUT',
        headers: {
            'Content-Type': 'application/json',
            'email':emailid,
            'College_Name':clg
          },
        body:JSON.stringify(data),
    }).then(response=> {
        if(response.status===200) {
            alert("Updated");
            window.location.reload('AfterLogin.html');
        }
    })
    .catch(error=>{
        alert("Some Error Occured,Please try after some time...")
    });

}

function deleteEducation(value)
{
    let text;
    if (confirm("Are you sure you want to delete this Item") == true) 
    {
        cl=JSON.parse(value);
        clg=cl.college_Uni;
        const form=document.getElementById('myFUpdate');
        form.addEventListener('submit', event=> {
            event.preventDefault();});
            let emailid=localStorage.getItem("Email");
            console.log(emailid);
            console.log(clg);
            fetch('https://localhost:7181/api/Education/Delete_Education', {
            method:'DELETE',
            headers: {
                'Content-Type': 'application/json',
                'email':emailid,
                'College_Name':clg
            }
        }).then(response=> {
            if(response.status===200) {
                alert("Deleted");
                window.location.reload('AfterLogin.html');
            }
        })
        .catch(error=>{
            alert("Some Error Occured,Please try after some time...")
        });
    } 
    else 
    {
    text = "You canceled!";
    }
}

function fetchFieldsw(value) {
    
    eddata=JSON.parse(value);
    console.log(value);
    console.log(eddata);
    localStorage.setItem("company",eddata.company_Name);
    let com=localStorage.getItem("company");
        console.log(com);
    const form = document.querySelector('#workFormupdate');
    
    a=form.querySelector('#w1').value=eddata.company_Name;
    console.log(a)
    form.querySelector('#w2').value=eddata.role;
    form.querySelector('#w3').value=eddata.startDate;
    form.querySelector('#w4').value=eddata.endDate;
    form.querySelector('#w5').value=eddata.description;

    openForm3();
}

function addWork() {

    const form=document.getElementById('workF');
    form.addEventListener('submit', event=> {
        event.preventDefault();});

        const formData = new FormData(form);

        const data=Object.fromEntries(formData);
        console.log(data);
        let emailid=localStorage.getItem("Email");
        
        fetch('https://localhost:7181/api/Work/Add_Work_Details', {
        method:'POST',
        headers: {
            'Content-Type': 'application/json',
            'email':emailid
          },
        body:JSON.stringify(data),
    }).then(response=> {
        if(response.status===200) {
            alert("Work Experience Added.")
            window.location.reload('AfterLogin.html');
        }
    })
    .catch(error=>{
        alert("Some Error Occured,Please try after some time...")
    });
}

function updateWork()
{
    const form=document.getElementById('workFupdate');
    form.addEventListener('submit', event=> {
        event.preventDefault();});

        const formData = new FormData(form);

        const data=Object.fromEntries(formData);
        console.log(data);
        let emailid=localStorage.getItem("Email");
        let com=localStorage.getItem("company");
        console.log(com);
        fetch('https://localhost:7181/api/Work/Update_Work_Details', {
        method:'PUT',
        headers: {
            'Content-Type': 'application/json',
            'email':emailid,
            'Company_Name':com
          },
        body:JSON.stringify(data),
    }).then(response=> {
        if(response.status===200) {
            alert("Updated");
            window.location.reload('AfterLogin.html');
        }
    })
    .catch(error=>{
        alert("Some Error Occured,Please try after some time...")
    });
}

function deleteWork(value) {

    let text;
    if (confirm("Are you sure you want to delete this Item") == true) 
    {
        co=JSON.parse(value);
        c=co.company_Name;
        const form=document.getElementById('myFUpdate');
        form.addEventListener('submit', event=> {
            event.preventDefault();});
            let emailid=localStorage.getItem("Email");
            console.log(emailid);
            console.log(c);
            fetch('https://localhost:7181/api/Work/Delete_Work_Details', {
            method:'DELETE',
            headers: {
                'Content-Type': 'application/json',
                'email':emailid,
                'Company_Name':c
            }
        }).then(response=> {
            if(response.status===200) {
                alert("Deleted");
                window.location.reload('AfterLogin.html');
            }
        })
        .catch(error=>{
            alert("Some Error Occured,Please try after some time...")
        });
    } 
    else 
    {
    text = "You canceled!";
    }
}

function fetchFieldsAdd(value){
    addata=JSON.parse(value);
    console.log(value);
    console.log(addata);
    localStorage.setItem("title",addata.title);
    const form = document.querySelector('#addFormupdate');
    
    a=form.querySelector('#a1').value=addata.title;
    console.log(a)
    form.querySelector('#a2').value=addata.achievments;
    form.querySelector('#a3').value=addata.publications;
    form.querySelector('#a4').value=addata.volunteering_Experiences;


    openForm5();

}

function addAdd() {
    const form=document.getElementById('addF');
    form.addEventListener('submit', event=> {
        event.preventDefault();});

        const formData = new FormData(form);

        const data=Object.fromEntries(formData);
        console.log(data);
        let emailid=localStorage.getItem("Email");
        
        fetch('https://localhost:7181/api/Additional/Add_Addtional_Details', {
        method:'POST',
        headers: {
            'Content-Type': 'application/json',
            'email':emailid
          },
        body:JSON.stringify(data),
    }).then(response=> {
        if(response.status===200) {
            alert("Work Experience Added.")
            window.location.reload('AfterLogin.html');
        }
    })
    .catch(error=>{
        alert("Some Error Occured,Please try after some time...")
    });
}

function updateAdd(){
    const form=document.getElementById('addFupdate');
    form.addEventListener('submit', event=> {
        event.preventDefault();});

        const formData = new FormData(form);

        const data=Object.fromEntries(formData);
        console.log(data);
        let emailid=localStorage.getItem("Email");
        let t=localStorage.getItem("title");
        console.log(t);
        fetch('https://localhost:7181/api/Additional/Update_Additional_Details', {
        method:'PUT',
        headers: {
            'Content-Type': 'application/json',
            'email':emailid,
            'Title':t
          },
        body:JSON.stringify(data),
    }).then(response=> {
        if(response.status===200) {
            alert("Updated");
            window.location.reload('AfterLogin.html');
        }
    })
    .catch(error=>{
        alert("Some Error Occured,Please try after some time...")
    });
}

function deleteAdd(value) {
    let text;
    if (confirm("Are you sure you want to delete this Item") == true) 
    {
        addd=JSON.parse(value);
        ti=addd.title;
        const form=document.getElementById('myFUpdate');
        form.addEventListener('submit', event=> {
            event.preventDefault();});
            let emailid=localStorage.getItem("Email");
            console.log(emailid);
            console.log(ti);
            fetch('https://localhost:7181/api/Additional/Delete_Additional_Details', {
            method:'DELETE',
            headers: {
                'Content-Type': 'application/json',
                'email':emailid,
                'Title':ti
            }
        }).then(response=> {
            if(response.status===200) {
                alert("Deleted");
                window.location.reload('AfterLogin.html');
            }
        })
        .catch(error=>{
            alert("Some Error Occured,Please try after some time...")
        });
    } 
    else 
    {
    text = "You canceled!";
    }
}

function deleteSkill(value) {
    let text;
    if (confirm("Are you sure you want to delete this Item") == true) 
    {
        sset=JSON.parse(value);
        sk=sset.skillName;
            let emailid=localStorage.getItem("Email");
            console.log(emailid);
            console.log(sk);
            fetch('https://localhost:7181/api/Skills/Delete_Skills', {
            method:'DELETE',
            headers: {
                'Content-Type': 'application/json',
                'email':emailid,
                'Skill_Name':sk
            }
        }).then(response=> {
            if(response.status===200) {
                alert("Deleted");
                window.location.reload('AfterLogin.html');
            }
        })
        .catch(error=>{
            alert("Some Error Occured,Please try after some time...")
        });
    } 
    else 
    {
    text = "You canceled!";
    }
}

function addSkill(){
    const form=document.getElementById('adds');
    form.addEventListener('submit', event=> {
        event.preventDefault();});

        const formData = new FormData(form);
        console.log(formData.skillName);
        const data=Object.fromEntries(formData);
        console.log(data.skillName);
        let emailid=localStorage.getItem("Email");
        
        fetch('https://localhost:7181/api/Skills/Add_Skills', {
        method:'POST',
        headers: {
            'Content-Type': 'application/json',
            'email':emailid,
            'Skill_Name':data.skillName
          },
        
    }).then(response=> {
        if(response.status===200) {
            alert("Skills Added.")
            window.location.reload('AfterLogin.html');
        }
    })
    .catch(error=>{
        alert("Some Error Occured,Please try after some time...")
    });
}

function fetchTrainer(value) {

    tradata=JSON.parse(value);
    console.log(value);
    console.log(tradata);  

    openForm7();
    const form = document.querySelector('#TrainerForm');
    
    a=form.querySelector('#t1').value=tradata.firstName;
    console.log(a);
    localStorage.setItem("userName",a);
    form.querySelector('#t2').value=tradata.lastName;
    form.querySelector('#t3').value=tradata.gender;
    form.querySelector('#t5').value=tradata.password;
    form.querySelector('#t6').value=tradata.phone;
    form.querySelector('#t7').value=tradata.city;
    form.querySelector('#t8').value=tradata.state;
    form.querySelector('#t9').value=tradata.country;
    form.querySelector('#t10').value=tradata.aboutme;
    form.querySelector('#t11').value=tradata.email;


}

function deleteProfile() {
    let text;
    if (confirm("Are you sure you want to delete your entire Profile") == true) 
    {
            let emailid=localStorage.getItem("Email");
            console.log(emailid);
            fetch('https://localhost:7181/api/TrainerControl/Delete_Trainer', {
            method:'DELETE',
            headers: {
                'Content-Type': 'application/json',
                'email':emailid,
            }
        }).then(response=> {
            if(response.status===200) {
                alert("Account Deleted Successfully");
                window.location.replace('LoginPage.html');
            }
        })
        .catch(error=>{
            alert("Some Error Occured,Please try after some time...")
        });
    } 
    else 
    {
    text = "You canceled!";
    }
}

function updateTrainer() {
    const form=document.getElementById('TF');
    form.addEventListener('submit', event=> {
        event.preventDefault();});

        const formData = new FormData(form);

        const trainerdata=Object.fromEntries(formData);
        console.log(trainerdata);
        let emailid=localStorage.getItem("Email");
        console.log(trainerdata);
        fetch('https://localhost:7181/api/TrainerControl/Update', {
        method:'PUT',
        headers: {
            'Content-Type': 'application/json',
            'email':emailid,
          },
        body:JSON.stringify(trainerdata),
    }).then(response=> {
        if(response.status===200) {
            alert("Profile Updated");
            window.location.reload('AfterLogin.html');
        }
    })
    .catch(error=>{
        alert("Some Error Occured,Please try after some time...")
    });
}

function logout() {
    let text;
    if (confirm("Are you sure, do you want to log out from the page...!") == true) 
    {
        window.location.href='LoginPage.html';
    }
    else{
        text="You canceled!";
    }
}