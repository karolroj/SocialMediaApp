import { Component, Input, input } from '@angular/core';

@Component({
  selector: 'app-static-modal',
  standalone: true,
  imports: [],
  templateUrl: './static-modal.component.html',
  styleUrl: './static-modal.component.css'
})
export class StaticModalComponent {
  @Input() title: string = '';
  @Input() content: string = '';
}
