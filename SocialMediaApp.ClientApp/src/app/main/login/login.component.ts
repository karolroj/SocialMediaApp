import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AccountService } from '../../services/account.service';
import { LoginRequest } from '../../interfaces/LoginRequest';
import { Modal } from 'bootstrap';
import { StaticModalComponent } from '../../modals/static-modal/static-modal.component';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, StaticModalComponent],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})

export class LoginComponent {
  constructor(private accountService: AccountService) { }

  serverResponse: string = "";

  loginForm: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', Validators.required),
  }, { updateOn: 'blur' });

  get email() {
    return this.loginForm.get('email');
  }

  get password() {
    return this.loginForm.get('password');
  }

  onSubmit() {
    if (this.loginForm.invalid) {
      this.loginForm.markAllAsTouched();
      return;
    }

    let request: LoginRequest = {
      email: this.email?.value,
      password: this.password?.value
    }

    let modal = new Modal(document.getElementById('staticModal')!);

    this.accountService.login(request).subscribe({
      error: (error) => {
        this.serverResponse = error.error.message;
        modal.show();
      },
    });
  }
}
