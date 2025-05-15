export interface RemoteResponse<T = any> {
  hasError?: boolean;
  error?: ErrorModel;
  data?: T;
}

export interface ErrorModel {
  errorCode?: number;
  errorMessage?: string;
}

