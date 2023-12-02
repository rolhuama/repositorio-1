import { FormGroup } from "@angular/forms";
import { Month } from "src/app/models/common/month.model";
import monthsList  from 'src/assets/data/months.json';


export class HelperFunction {

   public static hasErrorControl(controlName: string, form: FormGroup) {
        const control = form.get(controlName)
        return control?.touched && (control.hasError('required') || control.hasError('email') || control.hasError('minlength') || control.hasError('min'))
      }
    
     public static validateFirstGroup(controlGroup: string[], form: FormGroup) {
        let isValid: boolean = false
    
        controlGroup.forEach((controlName) => {
          const control = form.get(controlName);
          if (control) {
            control.markAsTouched();
          }
        });
    
        if (controlGroup.every((controlName) => form.get(controlName)?.valid)) {
          isValid = true
        }
    
        return isValid
      }

      public static GetMonths() {
        let list:Month[]=monthsList
       return list
      }

}
