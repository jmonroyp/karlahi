import { createAsyncThunk, createSlice, PayloadAction } from "@reduxjs/toolkit";
import { ILogin, ISession } from "../../domains/dtos/interfaces";
import { RootState, AppThunk } from "../../app/store";
import di from "../../di";

export interface ISessionState {
  token: string;
  user: string;
  status: "authenticated" | "notauthenticated" | "loading" | "error";
  errorMessage: string;
}

export class SessionState implements ISessionState {
  token: string = "";
  user: string = "";
  status: "authenticated" | "notauthenticated" | "loading" | "error" = "notauthenticated";
  errorMessage: string = "";
}

const initialState: SessionState = {
  token: "",
  user: "",
  status: "notauthenticated",
  errorMessage: "",
};


//actions
export const loginAsync = createAsyncThunk(
  "session/login",
  async (login: ILogin) => {
    const response = await di.session.authenticate(login.username, login.password);
    return {
      token: response,
      username: login.username,
    };
  }
);

export const logoutAsync = createAsyncThunk(
  "session/logout",
  async () => {
    await di.session.logout();
    return {
      token: '',
      username: '',
      status: 'notauthenticated'
    };
  }
);


export const sessionSlice = createSlice({
  name: "session",
  initialState,
  reducers: {
    getSession: (state) => {
      state.token = "kaka";
      state.user = "pipi";
      state.status = "authenticated";
    }
  },
  extraReducers: {
    [loginAsync.pending.type]: (state) => {
      state.status = "loading";
    },
    [loginAsync.fulfilled.type]: (state, action: PayloadAction<ISession>) => {
      console.log(action.payload);
      state.token = action.payload.token;
      state.user = action.payload.username;
      state.status = "authenticated";
    },
    [loginAsync.rejected.type]: (state) => {
      state.status = "error";
      state.token = "";
      state.user = "";
    },
    [logoutAsync.fulfilled.type]: (state) => {
      state.status = "notauthenticated";
      state.token = "";
      state.user = "";
    },
    [logoutAsync.rejected.type]: (state) => {
      state.status = "loading";
    },
    [logoutAsync.rejected.type]: (state) => {
      state.status = "error";
    }
  },
});

export const { getSession } = sessionSlice.actions;

// The function below is called a selector and allows us to select a value from
// the state. Selectors can also be defined inline where they're used instead of
// in the slice file. For example: `useSelector((state: RootState) => state.counter.value)`
export const session = (state: RootState) => state.session;

export default sessionSlice.reducer;
