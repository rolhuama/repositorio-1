import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ScriptLoaderService } from 'src/app/services/script-loader.service';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class FooterComponent implements OnInit {

  constructor(
    private scriptLoaderService:ScriptLoaderService
  ) { }

  ngOnInit(): void {
    const scriptsToLoad = [
      'assets/js/main.min.js'
    ];

    // this.scriptLoaderService.loadScripts(scriptsToLoad)
  }

}
