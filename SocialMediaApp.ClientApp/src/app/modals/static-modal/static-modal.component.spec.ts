import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StaticModalComponent } from './static-modal.component';

describe('StaticModalComponent', () => {
  let component: StaticModalComponent;
  let fixture: ComponentFixture<StaticModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StaticModalComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(StaticModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
