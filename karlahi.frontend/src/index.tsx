import React from "react";
import "./index.css";
import App from "./App";
import { store } from "./app/store";
import { Provider } from "react-redux";

import { createRoot } from "react-dom/client"; // createRoot is a function that takes a component and returns a root element
const root = createRoot(document.getElementById("root") as HTMLElement); // createRoot(container!) if you use TypeScript
root.render(
  <React.StrictMode>
    <Provider store={store}>
      <App />
    </Provider>
  </React.StrictMode>
);