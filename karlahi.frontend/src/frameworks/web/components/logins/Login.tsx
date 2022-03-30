import * as React from "react";
import { useSetToken } from "@hooks/sessionRecoil";
import AuthForm from "./AuthForm";
import di from "@di";

const Login: React.FC = () => {
  const setToken = useSetToken();

  const handleClickAccreditation = async (id: string, pw: string) => {
    const token = await di.session.login(id, pw);
    di.session.setToken(token);
    setToken(token);
  };

  return (
    <div className="ui text container">
      <div className="ui one column grid">
        <div className="column">
          <h3 className="ui header aligned center">Welcome to Karlart</h3>
          <AuthForm accredit={handleClickAccreditation} btnValue={"Login"} />
        </div>
      </div>
    </div>
  );
};

export default Login;
