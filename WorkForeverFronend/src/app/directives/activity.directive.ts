import {Directive, ElementRef, Input} from '@angular/core';

@Directive({
  selector: '[appActivity]'
})

export class ActivityDirective {
  //default value = 1970-01-01
  @Input() LastWork : Date = new Date(0);
  time_passed : number = 0;
  constructor(
    private el : ElementRef,
  ) {
    // if the last work was more than 1 day ago, the player is inactive
    this.time_passed = Date.now() - this.LastWork.getTime();
    if (this.time_passed < 5*60*1000)
      this.highlight('green');
    if (this.time_passed < 24*60*60*1000)
      this.highlight('yellow');
    else
      this.highlight('red');
  }

  highlight(color: string) {
    this.el.nativeElement.style.backgroundColor = color;
  }

}
