import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import { HashRouter, Route, Routes } from 'react-router'
import Info from './Info.tsx'

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <HashRouter>
      <Routes>
        <Route path="/:url?" element={<App />}></Route>
        <Route path='/info/:url?' element={<Info />}></Route>

        

      </Routes>
      
      
    </HashRouter>
    
  </StrictMode>,
)
