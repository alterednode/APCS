class Pascal {
    public List<List<Integer>> generate(int numRows) {
        
        List<List<Integer>> output = new ArrayList<>();
        List<Integer> toAdd = new ArrayList<>(1);
        output.add(toAdd);
        

        for (int i = 1; i < numRows; i++){
            for (int j = 0; j <= i; j++){
            toAdd.clear();
            if (j == i){
                toAdd.add(1);
            }
            if (j == 0){
                toAdd.add(1);
            }else{
                toAdd.add(output.get(i-1).get(j-1)+output.get(i-1).get(j));
            }
                output.add(toAdd);
            }
        }
        
        
        
        
        
        return output;
        
    }
}