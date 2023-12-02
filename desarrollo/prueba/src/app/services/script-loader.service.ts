import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ScriptLoaderService {
  private loadedScripts: { [url: string]: boolean } = {};
  private loadedStyles: { [url: string]: boolean } = {};

  loadScripts(scriptUrls: string[]): void {

    for (const url of scriptUrls) {
      if (!this.loadedScripts[url]) {
        const script = document.createElement('script');
        script.src = url;
        document.head.appendChild(script);

        this.loadedScripts[url] = true;
      }
    }
  }

  loadStyles(styleUrls: string[]) {

    for (const url of styleUrls) {
      if (!this.loadedStyles[url]) {
        const link = document.createElement('link');
        link.rel = 'stylesheet';
        link.href = url;
        document.head.appendChild(link);

        this.loadedStyles[url] = true;
      }
    }
  }
}
