import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ReactiveFormsModule, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { AccountService } from '../../services/account.service';
import { Register } from '../../interfaces/Register';
import { Modal } from 'bootstrap';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  serverResponse: string = "";
  constructor(private accountService: AccountService) { }

  registerForm: FormGroup = new FormGroup({
    name: new FormControl('', Validators.required),
    surname: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', Validators.required),
    confirmPassword: new FormControl('', Validators.required)
  }, { validators: this.passwordMatch(), updateOn: 'blur' });

  private passwordMatch(): ValidatorFn | ValidatorFn[] | null | undefined {
    return (control: AbstractControl): ValidationErrors | null => {
      const password = control.get('password');
      const confirmPassword = control.get('confirmPassword');

      if (password?.value !== confirmPassword?.value) {
        confirmPassword?.setErrors({ passwordMatch: true });
      }

      return null;
    }
  }

  get name() {
    return this.registerForm.get('name');
  }

  get surname() {
    return this.registerForm.get('surname');
  }

  get email() {
    return this.registerForm.get('email');
  }

  get password() {
    return this.registerForm.get('password')
  }

  get confirmPassword() {
    return this.registerForm.get('confirmPassword');
  }

  onSubmit() {
    if (this.registerForm.invalid) {
      this.registerForm.markAllAsTouched();
      return;
    }

    let registerRequest: Register = {
      name: this.name!.value,
      surname: this.surname!.value,
      email: this.email!.value,
      password: this.password!.value,
      passwordConfirm: this.confirmPassword!.value
    };

    let modal = new Modal(document.getElementById('registrationModal')!);

    this.accountService.register(registerRequest).subscribe({
      next: (response: any) => {
        this.serverResponse = response.message;
        modal.show();
      },
      error: (error) => {
        this.serverResponse = error.error.message;
        modal.show();
      },
      complete: () => {
        this.registerForm.reset();
      }
    });
  }
}
