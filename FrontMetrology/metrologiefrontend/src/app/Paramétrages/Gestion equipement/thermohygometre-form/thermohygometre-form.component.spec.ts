import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ThermohygometreFormComponent } from './thermohygometre-form.component';

describe('ThermohygometreFormComponent', () => {
  let component: ThermohygometreFormComponent;
  let fixture: ComponentFixture<ThermohygometreFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ThermohygometreFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ThermohygometreFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
