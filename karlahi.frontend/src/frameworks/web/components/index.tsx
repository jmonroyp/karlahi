import * as React from "react";
import { useEffect } from "react";
import { useTokenState } from "@hooks/sessionRecoil";
import di from "@di";
import Login from "./logins/Login";
import Layout from "./common/Layout";

const Index: React.FC = () => {
  const [token, setToken] = useTokenState();

  useEffect(() => {
    (async () => {
      const storageToken = await di.session.getToken();
      if (storageToken) {
        di.session.setToken(storageToken);
        setToken(storageToken);
      }
    })();
  }, [token]);

  return (
    <>
      {token === "" && (
        <div className="row d-flex justify-content-center">
          <div className="col-md-4">
            <Login />
          </div>
        </div>
      )}
      {token && (
        <Layout>
          <p>Hola esto es un layout</p>
        </Layout>
      )}
    </>
  );
};

export default Index;
