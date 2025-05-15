import { L10n, setCulture } from '@syncfusion/ej2-base';

export function initializeSyncfusionLocale() {
  // Imposta la cultura italiana come default
  setCulture('it-IT');

  // Carica le traduzioni italiane
  L10n.load({
    'it-IT': {
      'grid': {
        'Add': 'Aggiungi',
        'EmptyRecord': 'Nessun record da visualizzare',
        'FilterButton': 'Filtro',
        'ClearButton': 'Pulisci',
        'StartsWith': 'Inizia con',
        'EndsWith': 'Finisce con',
        'Contains': 'Contiene',
        'Equal': 'Uguale a',
        'NotEqual': 'Diverso da',
        'LessThan': 'Minore di',
        'LessThanOrEqual': 'Minore o uguale a',
        'GreaterThan': 'Maggiore di',
        'GreaterThanOrEqual': 'Maggiore o uguale a',
        'ChooseDate': 'Scegli una data',
        'FilterMenu': 'Filtro',
        'SelectAll': 'Seleziona tutto',
        'Blanks': 'Vuoti',
        'FilterTrue': 'Vero',
        'FilterFalse': 'Falso',
        'NoResult': 'Nessun risultato trovato',
        'SearchPlaceholder': 'Cerca',
        'Clear': 'Pulisci',
        'And': 'E',
        'Or': 'O',
        'CustomFilter': 'Filtro personalizzato',
        'CustomFilterPlaceHolder': 'Inserisci il valore',
        'CustomFilterDatePlaceHolder': 'Scegli una data',
        'matchcase': 'Maiuscole/minuscole',
        'Between': 'Tra',
        'BetweenStartDate': 'Data inizio',
        'BetweenEndDate': 'Data fine',
        'DateTimeFilter': 'Filtro Data',
        'DateFilter': 'Filtro Data',
        'ShowDatePickerButton': 'Mostra Calendario'
      },
      'pager': {
        'currentPageInfo': '{0} di {1} pagine',
        'totalItemsInfo': '({0} elementi)',
        'firstPageTooltip': 'Prima pagina',
        'lastPageTooltip': 'Ultima pagina',
        'nextPageTooltip': 'Pagina successiva',
        'previousPageTooltip': 'Pagina precedente',
        'nextPagerTooltip': 'Vai al prossimo set di pagine',
        'previousPagerTooltip': 'Vai al precedente set di pagine'
      },
      'datepicker': {
        'months': {
          'names': [
            'Gennaio', 'Febbraio', 'Marzo', 'Aprile', 'Maggio', 'Giugno',
            'Luglio', 'Agosto', 'Settembre', 'Ottobre', 'Novembre', 'Dicembre'
          ],
          'namesAbbr': [
            'Gen', 'Feb', 'Mar', 'Apr', 'Mag', 'Giu',
            'Lug', 'Ago', 'Set', 'Ott', 'Nov', 'Dic'
          ]
        },
        'days': {
          'names': ['Domenica', 'Lunedì', 'Martedì', 'Mercoledì', 'Giovedì', 'Venerdì', 'Sabato'],
          'namesAbbr': ['Dom', 'Lun', 'Mar', 'Mer', 'Gio', 'Ven', 'Sab']
        },
        'placeholder': 'Seleziona una data',
        'today': 'Oggi'
      },
      'calendar': {
        'today': 'Oggi',
        'months': {
          'names': [
            'Gennaio', 'Febbraio', 'Marzo', 'Aprile', 'Maggio', 'Giugno',
            'Luglio', 'Agosto', 'Settembre', 'Ottobre', 'Novembre', 'Dicembre'
          ],
          'namesAbbr': [
            'Gen', 'Feb', 'Mar', 'Apr', 'Mag', 'Giu',
            'Lug', 'Ago', 'Set', 'Ott', 'Nov', 'Dic'
          ]
        },
        'days': {
          'names': ['Domenica', 'Lunedì', 'Martedì', 'Mercoledì', 'Giovedì', 'Venerdì', 'Sabato'],
          'namesAbbr': ['Dom', 'Lun', 'Mar', 'Mer', 'Gio', 'Ven', 'Sab']
        }
      },


    }
  });
}
