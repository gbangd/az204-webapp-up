import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ImageDimensions } from './image-dimensions';
import { ImageResult, TestService } from './test.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'azstaticwebtest';
  dimensions! : ImageDimensions;
  imageUrl: ImageResult = { url :"../assets/1.jpg"} ;
  imageName: string = "default_name";

  constructor(private testService:TestService){
    this.dimensions = new ImageDimensions();
  }

  generateImage(){
    this.testService.generateImage(this.dimensions, this.imageName).subscribe(
      {
        next: url => this.imageUrl = url,
        error: e => console.log(e),
        complete: () => console.log(this.imageUrl)
      });
  }
}
