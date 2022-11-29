import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RefregirateurFormComponent } from './refregirateur-form.component';

describe('RefregirateurFormComponent', () => {
  let component: RefregirateurFormComponent;
  let fixture: ComponentFixture<RefregirateurFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RefregirateurFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RefregirateurFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
