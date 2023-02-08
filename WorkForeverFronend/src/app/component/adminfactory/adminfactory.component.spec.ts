import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminfactoryComponent } from './adminfactory.component';

describe('AdminfactoryComponent', () => {
  let component: AdminfactoryComponent;
  let fixture: ComponentFixture<AdminfactoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminfactoryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminfactoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
