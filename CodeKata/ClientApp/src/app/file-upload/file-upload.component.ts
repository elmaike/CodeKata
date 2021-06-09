import { Component, OnInit, Output } from '@angular/core';
import { HttpEventType, HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
@Component({
  selector: 'app-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css']
})
export class UploadComponent implements OnInit {  
  public results: any;  
  constructor(private http: HttpClient) { }
  ngOnInit() {
    this.results = null;
  }
  public uploadFile = (files) => {
    if (files.length === 0) {
      return;
    }
    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    this.http.post('https://localhost:44355/api/fileupload', formData)
      .subscribe((response: any) => {
        this.results = response;             
      });
  }
}
