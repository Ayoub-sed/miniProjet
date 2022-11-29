import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TunnelDeRefroidissementFormComponent } from './tunnel-de-refroidissement-form.component';

describe('TunnelDeRefroidissementFormComponent', () => {
  let component: TunnelDeRefroidissementFormComponent;
  let fixture: ComponentFixture<TunnelDeRefroidissementFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TunnelDeRefroidissementFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TunnelDeRefroidissementFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
