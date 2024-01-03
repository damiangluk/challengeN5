import './App.css';
import NavigationContainer from './components/NavigationContainer/NavigationContainer';
import { Container } from '@mui/material';
import { BrowserRouter as Router } from "react-router-dom";

const App = () => {
  return (
    <div className="App">
      <div className="body-tables">
        <Container>
          <Router>
            <NavigationContainer />
          </Router>
        </Container>

      </div>
    </div>
  );
}

export default App;
