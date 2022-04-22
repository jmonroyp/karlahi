import * as React from "react";
import { useState } from "react";

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
    <form className="ui form">
      <div className="field">
        <input
          name="id"
          className="form-control"
          type="text"
          placeholder="Ingresar usuario"
          onChange={handleChangeClientInfo}
          value={id}
        />
      </div>
      <div className="field">
        <input
          type="password"
          name="pw"
          className="form-control"
          placeholder="Ingresar password"
          onChange={handleChangeClientInfo}
          onKeyDown={handleKeyDownAccredit}
          value={pw}
        />
      </div>
      <div className="field">
        <button className="fluid ui primary button" type="button" onClick={handleClickAccredit}>
          {btnValue}
        </button>
      </div>
    </form>
  );
};

export default AuthForm;
