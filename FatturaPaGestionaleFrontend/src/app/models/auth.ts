export interface Auth{
  data?: detailAuth;
  hasError?: boolean;
  error?:string;
}

export interface detailAuth{
  cf?: string;
  email?: string;
  error?: boolean;
  errorDescription?: string;
  guidUtente?: string;
  initials: string;
  ruolo?: string;
  token?: string;
  tenantId?: string;
}
