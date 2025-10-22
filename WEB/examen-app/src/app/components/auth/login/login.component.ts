import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ApiService } from  '../../../services/api.service';
import { Router } from '@angular/router';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, NgIf],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent implements OnInit {
  form!: FormGroup;
  error = '';

  constructor (private fb: FormBuilder, private api: ApiService, private router: Router){
   this.form = this.fb.group({ email: [''], password: [''] });
  }
 ngOnInit(): void {
   
 }
  login() {
    this.api.post('login', this.form.value)
    .subscribe({
      next: (res) => {
        localStorage.setItem('token', res.token);
        this.router.navigate(['/projects']);
      },
      error: () => this.error = 'Credenciales incorrectas'
    });
  }
}
