import {Directive, ElementRef, HostListener, Input} from '@angular/core';

@Directive({
  selector: '[appActivity]'
})

export class ActivityDirective {
  //default value = 1970-01-01
  @Input("appActivity") LastWork : Date = new Date(0);
  time_passed : number = 0;
  constructor(
    private el : ElementRef,
  ) {
    console.log("LastWork: ", this.LastWork);

  }
  @HostListener('mouseenter') onMouseEnter() {
    console.log("onMouseEnter");
    this.time_passed = Date.now() - new Date(this.LastWork).getTime();
    console.log ("Date.now(): ", new Date(Date.now()));
    console.log ("new Date(this.LastWork).getTime(): ", new Date(this.LastWork));
    console.log("time_passed: ", this.time_passed);
    if (this.time_passed < 5*60*1000)
      this.highlight('green');
    else if (this.time_passed < 24*60*60*1000)
      this.highlight('yellow');
    else
      this.highlight('red');
  }
  @HostListener('mouseleave') onMouseLeave() {
    console.log("onMouseLeave");
    this.highlight("");
  }

  highlight(color: string) {
    this.el.nativeElement.style.backgroundColor = color;
  }

}
