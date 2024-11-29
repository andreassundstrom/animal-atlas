import { CssBaseline } from '@mui/material'
import './App.css'
import { Router } from './layout/router'
import { ApiContext } from './contexts/ApiContext'

function App() {

  return (
    <>
    <CssBaseline />
    <ApiContext>
      <Router />
    </ApiContext>
    </>
  )
}

export default App
