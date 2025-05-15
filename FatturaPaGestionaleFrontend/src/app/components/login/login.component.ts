import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { FormValidator, FormValidators } from '@syncfusion/ej2-angular-inputs';
import { LoginService } from 'src/app/services/login.service';
import { Auth } from 'src/app/models/auth';
import { LoginDto } from 'src/app/models/dto/loginDto';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  standalone: false
})
export class LoginComponent {
  loginForm: FormGroup;
  showPassword = false;
  errorMessage:string = 'ciao';
  rejected: boolean=false;
  credentials: LoginDto = new LoginDto();

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private authService: AuthService,
    private loginService:LoginService,
  ) {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  ngOnInit(){
    if(localStorage.getItem('token')!=null){
      this.router.navigate(['/tenants']);
    }
  }

  togglePasswordVisibility() {
    this.showPassword = !this.showPassword;
  }

  async onSubmit() {
    if (this.loginForm.valid) {
      const { username, password } = this.loginForm.value;

      this.credentials.email=username;
      this.credentials.password=password;

      var auth: Auth = await this.loginService.loginStorage(this.credentials);
      console.log(auth);

      if (auth?.data?.error==false){
        this.router.navigate(['/tenants']);
      }else{
        this.rejected=true
        this.errorMessage=auth?.data?.errorDescription!;
        console.log(this.errorMessage);
      }



    }
  }

}
