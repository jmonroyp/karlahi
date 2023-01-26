export interface ISessionState {
  token: string;
  user: string;
  status: "authenticated" | "notauthenticated" | "loading" | "error";
  errorMessage: string;
}

export class SessionState implements ISessionState {
  token: string = "";
  user: string = "";
  status: "authenticated" | "notauthenticated" | "loading" | "error" =
    "notauthenticated";
  errorMessage: string = "";
}
