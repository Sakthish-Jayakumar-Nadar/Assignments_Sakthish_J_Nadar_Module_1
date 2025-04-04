import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MemberLoansComponent } from './member-loans.component';

describe('MemberLoansComponent', () => {
  let component: MemberLoansComponent;
  let fixture: ComponentFixture<MemberLoansComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MemberLoansComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MemberLoansComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
