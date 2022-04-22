import * as React from "react";
import AuthForm from "./AuthForm";
import { loginAsync, logoutAsync, session } from "../../features/session/sessionSlice";
import "./logins.css";
import LoginDto from "../../domains/dtos/Login";
import { useAppSelector, useAppDispatch } from '../../app/hooks';




const Login: React.FC = () => {
  const dispatch = useAppDispatch();
  const currentSession = useAppSelector(session);

  
  // useEffect(() => {
  //   dispatch(GetPosts());
  // }, []);

  const handleLogin = async (id: string, pw: string) => {
    dispatch(loginAsync(new LoginDto(id, pw)));
  };

  

  const renderedAlert = currentSession.status !== "error" ? (
    ""
  ) : (
    <div className="ui red message">
      Usuario y/o Contraseña invalidos
    </div>
  );

  const loading = currentSession.status === "loading" ? <div>Iniciando sesión...</div> : "";

  return (
    <div className="auth-form">
      <h3>Bienvenido</h3>
      <AuthForm accredit={handleLogin} btnValue={"Entrar"} />
      <div className="ui divider"></div>
      {renderedAlert}
      {loading}
      <p>
        ¿Olvidaste tu contraseña? <a href="/">Click aquí</a>
      </p>
    </div>
  );
};

export default Login;
