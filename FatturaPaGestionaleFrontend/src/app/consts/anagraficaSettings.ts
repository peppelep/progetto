import { DropdownItemString } from "./dropDownItem";

export const AN_TIPOLOGIA: DropdownItemString[] = [
    { label: '', value: undefined },
    { label: 'Azienda', value: 'A' },
    { label: 'Persona', value: 'P' },
    { label: 'Condominio', value: 'C' },
    { label: 'Ente pubblico o simile', value: 'E' },
    { label: 'Altro', value: 'O' }
];

export const AN_TIPO_ANAGRAFICA: DropdownItemString[] = [
    { label: 'Cliente', value: 'C' },
    { label: 'Fornitore', value: 'F' },
    { label: 'Interno', value: 'I' }
];

export const AN_TIPO_ANAGRAFICAnoRequired: DropdownItemString[] = [
  { label: '', value: '' },
  { label: 'Cliente', value: 'C' },
  { label: 'Fornitore', value: 'F' },
  { label: 'Interno', value: 'I' }
];

export const AN_PERIODO: DropdownItemString[] = [
  { label: '', value: undefined },
    { label: 'Fine mese', value: 'F' },
    { label: 'giorni effettivi dalla data fattura', value: 'G' }
];

export const AN_LETTERA_INTENTO: DropdownItemString[] = [
  { label: '', value: undefined },
  { label: 'Presente', value: 'S' },
  { label: 'Assente', value: 'N' }
];

export const AN_STATO: DropdownItemString[] = [
  { label: '', value: undefined },
  { label: 'Attivo', value: 'Attivo' },
  { label: 'Sospeso', value: 'Sospeso' },
  { label: 'In lavorazione', value: 'In lavorazione' },
];



