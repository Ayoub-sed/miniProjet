import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DebimetreVolumetriqueFormComponent } from './debimetre-volumetrique-form.component';

describe('DebimetreVolumetriqueFormComponent', () => {
  let component: DebimetreVolumetriqueFormComponent;
  let fixture: ComponentFixture<DebimetreVolumetriqueFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DebimetreVolumetriqueFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DebimetreVolumetriqueFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
