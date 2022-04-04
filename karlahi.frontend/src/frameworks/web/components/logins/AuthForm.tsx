import * as React from "react";
import { useState } from "react";
import { Form, Button } from "react-bootstrap";

interface IProps {
  accredit(id: string, pw: string): void;
  btnValue: string;
}

const AuthForm: React.FC<IProps> = (props) => {
  const { accredit, btnValue } = props;
  const [id, setId] = useState<string>("");
  const [pw, setPw] = useState<string>("");

  const handleChangeClientInfo = (
    event: React.ChangeEvent<HTMLInputElement>
  ): void => {
    const updateFnc = event.target.name === "id" ? setId : setPw;
    updateFnc(event.target.value);
  };

  const handleClickAccredit = () => {
    accredit(id, pw);
  };

  const handleKeyDownAccredit = (event: React.KeyboardEvent) => {
    if (event.key === "Enter") {
      accredit(id, pw);
    }
  };

  return (
    <Form className="form-group">
      <Form.Group className="mb-3">
        <Form.Label>Usuario</Form.Label>
        <Form.Control
          name="id"
          type="text"
          placeholder="Ingresar usuario"
          onChange={handleChangeClientInfo}
          value={id}
        />
      </Form.Group>
      <Form.Group className="mb-3">
        <Form.Label>Contraseña</Form.Label>
        <Form.Control
          type="password"
          name="pw"
          placeholder="Ingresar password"
          onChange={handleChangeClientInfo}
          onKeyDown={handleKeyDownAccredit}
          value={pw}
        />
      </Form.Group>
      <Form.Group className="mb-3">
        <Button variant="primary" type="button" onClick={handleClickAccredit}>
          Entrar
        </Button>
      </Form.Group>
    </Form>
  );
};

export default AuthForm;
