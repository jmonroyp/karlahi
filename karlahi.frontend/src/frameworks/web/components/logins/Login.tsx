import * as React from "react";
import { useSetToken } from "@hooks/sessionRecoil";
import AuthForm from "./AuthForm";
import di from "@di";
import { Alert } from "react-bootstrap";
import "./logins.css";

const Login: React.FC = () => {
  const setToken = useSetToken();
  const [errorMessage, setErrorMessage] = React.useState<string>("");

  const handleClickAccreditation = async (id: string, pw: string) => {
    const token = await di.session.login(id, pw);
    if (token !== "") {
      di.session.setToken(token);
      setToken(token);
    } else {
      setErrorMessage("Usuario y/o contraseña inválida");
    }
  };

  const renderedAlert = !errorMessage ? (
    ""
  ) : (
    <Alert variant="danger">
      <p className="error-p">{errorMessage}</p>
    </Alert>
  );

  return (
    <div className="auth-form">
      <h3>Bienvenido a KarlArt</h3>
      <AuthForm accredit={handleClickAccreditation} btnValue={"Login"} />
      {renderedAlert}
      <p>
        ¿Olvidaste tu contraseña? <a href="#">Click aquí</a>
      </p>
    </div>
  );
};

export default Login;
