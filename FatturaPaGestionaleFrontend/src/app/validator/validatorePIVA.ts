import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

/**
 * Funzione di supporto che verifica se la partita IVA rispetta:
 * - lunghezza di 11 caratteri
 * - solo cifre
 * - corretto algoritmo di controllo (check sum)
 */
export function partitaIvaValida(piva: string): boolean {
  // Controlla che abbia esattamente 11 cifre
  if (!/^[0-9]{11}$/.test(piva)) {
    return false;
  }

  let somma = 0;
  for (let i = 0; i < 11; i++) {
    let cifra = +piva.charAt(i);

    // Se l'indice è pari (0-based), aggiunge la cifra così com'è
    // Se l'indice è dispari, raddoppia la cifra e, se > 9, sottrae 9
    if (i % 2 === 0) {
      somma += cifra;
    } else {
      cifra = cifra * 2;
      if (cifra > 9) {
        cifra = cifra - 9;
      }
      somma += cifra;
    }
  }

  // La partita IVA è valida se la somma è multipla di 10
  return somma % 10 === 0;
}

/**
 * ValidatorFn per Angular che utilizza la funzione partitaIvaValida()
 */
export function partitaIvaValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const value = control.value as string;

    if (!value) {
      return null; // se il campo è vuoto, non validiamo qui la richiesta (potresti usare Validators.required a parte)
    }

    // Se la partita IVA è sbagliata, restituiamo un errore
    if (!partitaIvaValida(value)) {
      return { partitaIvaNonValida: true };
    }

    // Altrimenti nessun errore
    return null;
  };
}
