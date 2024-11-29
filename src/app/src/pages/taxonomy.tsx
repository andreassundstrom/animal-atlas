import { Box, Typography } from "@mui/material"
import { TaxonomyContext } from "../contexts/TaxonomyContext"
import { TaxonomyListBase } from "../components/taxonomy/taxonomyListBase"



export const Taxonomy = () => {
    
    return <Box>
        <Typography variant="h3">Taxonomy items</Typography>
        <TaxonomyContext>
            <TaxonomyListBase />
        </TaxonomyContext>
        </Box>
}