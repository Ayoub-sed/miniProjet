import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ThermometreFormComponent } from './thermometre-form.component';

describe('ThermometreFormComponent', () => {
  let component: ThermometreFormComponent;
  let fixture: ComponentFixture<ThermometreFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ThermometreFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ThermometreFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
