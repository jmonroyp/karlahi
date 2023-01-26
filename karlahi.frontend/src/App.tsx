import "./App.css";
import Login from "./components/logins/";
import { session } from "./features/session/sessionSlice";
import { useAppSelector, useAppDispatch } from "./app/hooks";

function App() {
  const currentSession = useAppSelector(session);
  // if not authenticated, show login
  if (currentSession.status !== "authenticated") {
    return <Login />;
  } else {
    return (
      <div className="app-body">
        home
      </div>
    );
  }
}

export default App;
